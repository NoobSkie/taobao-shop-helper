using System;

namespace J.SLS.Database.ORM
{
    /// <summary>
    /// ʵ��������ע�����ڱ�עʵ����洢�����ݿ��еı���
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class EntityMappingTableAttribute : Attribute
    {
        /// <summary>
        /// ʵ����ӳ�䵽���ݿ�ı���������Ϊnull��մ�
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// ָ��ӳ��Ķ����Ƿ���һ��ֻ������
        /// �����ָ��Ϊֻ������,�ڶԴ˶���������ɾ���Ĳ���ʱ,���׳���Ӧ�쳣
        /// </summary>
        public bool ReadOnly { get; set; }

        /// <summary>
        /// ����ʵ����ӳ��ı�������������Ϊnull��մ�
        /// </summary>
        /// <exception cref="RException(RErrorCode.ArgmentesError - 0x00000014)">
        /// ����������������쳣��
        /// 1.�����tableNameΪnull��մ�ʱ
        /// </exception>
        /// <param name="tableName">��־û�����ӳ������ݿ����</param>
        public EntityMappingTableAttribute(string tableName)
        {
            this.TableName = tableName;
            this.ReadOnly = false;
        }
    }
}